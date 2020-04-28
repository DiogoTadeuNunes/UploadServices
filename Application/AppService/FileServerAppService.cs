using Application.Common;
using Application.InputModel;
using Application.Interfaces;
using Application.ViewModel;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Application.AppService
{
    public class FileServerAppService : IFileServerAppService
    {
        private readonly IFileRepository _repository;
        private readonly IPostRepository _postRepository;

        public FileServerAppService(
            IFileRepository repository,
            IPostRepository postRepository)
        {
            _repository = repository;
            _postRepository = postRepository;
        }

        private static readonly string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "Resources");

        public UploadViewModel Upload(IFormFile file, string virtualPath)
        {
            UploadViewModel result;

            var fileExtension = string.Empty;
            if (file.ContentType != null)
            {
                fileExtension = Helpers.GetExtension(file.ContentType).Replace(".", "");
            }
            else
            {
                string[] split = file.FileName.Split(".");
                fileExtension = split[split.Length - 1];
            }

            var filename = Guid.NewGuid().ToString() + "." + fileExtension;
            var fullPath = Path.Combine(pathToSave, filename);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            result = new UploadViewModel(virtualPath, filename, fileExtension);
            return result;
        }

        public UploadImageViewModel UploadImage(UploadImageInputModel data, string virtualPath)
        {
            UploadImageViewModel result;

            if (data.name == null)
                data.name = Guid.NewGuid();

            var fileExtension = "png";

            var file = data.base64;
            if (file.Contains("data:"))
            {
                try
                {
                    data.base64 = file.Split(",")[1];
                    fileExtension = file.Split(",")[0].Split(";")[0].Split("/")[1];
                }
                catch (Exception) { }
            }

            byte[] bytes = Convert.FromBase64String(data.base64);

            var filename = data.name + "." + fileExtension;
            var fullPath = Path.Combine(pathToSave, filename);

            if (bytes.Length > 0)
            {
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }
            }

            result = new UploadImageViewModel(virtualPath, filename, fileExtension);
            return result;
        }

        public CreatePostViewModel CreatePost(CreatePostInputModel data)
        {
            var post = new Post(data.projectKey, data.title, data.content);

            var files = data.files.Select(x => new Domain.Entities.File(x.name, x.session, post));

            foreach (var file in files)
            {
                _repository.Create(file);
            }
            
            return new CreatePostViewModel(
                post.Id,
                post.CreatedAt,
                post.ProjectKey,
                post.Title,
                post.Content,
                files.Select(x => new CreatePostViewModel.CreatePostFiles(x.Name, x.Session))
            );
        }

        public UpdatePostViewModel UpdatePost(UpdatePostInputModel data)
        {
            var files = _repository.GetByPostId(data.id);

            var post = files.FirstOrDefault().Post;
            post.Title = data.title;
            post.Content = data.content;

            foreach (var file in files)
            {
                file.Post = post;
                _repository.Update(file);
            }

            return new UpdatePostViewModel(
                post.Id,
                post.CreatedAt,
                post.ProjectKey,
                post.Title,
                post.Content,
                files.Select(x => new UpdatePostViewModel.UpdatePostFiles(x.Name, x.Session))
            );
        }

        public bool DeletePost(int id, string projectKey)
        {
            var post = _postRepository.GetById(id, projectKey);

            _postRepository.Delete(post);

            return true;
        }

        public IEnumerable<ListPostsViewModel> ListPosts(ListPostsInputModel data, string virtualPath)
        {
            var posts = _postRepository.ListByProjectKey(data.projectKey, data.createdAt);

            var postsVM = posts.Select(p => new ListPostsViewModel(
                p.Id, 
                p.CreatedAt, 
                p.ProjectKey, 
                p.Title,
                p.Content,
                p.Files.Select(f => new ListPostsViewModel.ListPostFiles(
                    $"{virtualPath}/{f.Name}",
                    f.Session
                )))
            );

            return postsVM;
        }

        public GetPostByIdViewModel GetPostById(GetPostByIdInputModel data, string virtualPath)
        {
            var posts = _postRepository.GetById(data.id, data.projectKey);

            var postsVM = new GetPostByIdViewModel(
                posts.Id,
                posts.CreatedAt,
                posts.ProjectKey,
                posts.Title,
                posts.Content);

            return postsVM;
        }
    }
}
