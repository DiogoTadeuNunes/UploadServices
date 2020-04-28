using Application.InputModel;
using Application.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IFileServerAppService
    {
        UploadViewModel Upload(IFormFile file, string virtualPath);

        UploadImageViewModel UploadImage(UploadImageInputModel data, string virtualPath);

        CreatePostViewModel CreatePost(CreatePostInputModel data);

        UpdatePostViewModel UpdatePost(UpdatePostInputModel data);

        bool DeletePost(int id, string projectKey);

        IEnumerable<ListPostsViewModel> ListPosts(ListPostsInputModel data, string virtualPath);

        GetPostByIdViewModel GetPostById(GetPostByIdInputModel data, string virtualPath);
    }
}
