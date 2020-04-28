using Application.Customizations.HubVeiculos.Enuns;
using Application.Customizations.HubVeiculos.Helpers;
using Application.Customizations.HubVeiculos.ViewModel;
using Application.InputModel;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileServerAppService _service;

        public FileController(IFileServerAppService service)
        {
            _service = service;
        }

        #region File Uploads

        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public IActionResult Upload(IFormFile file)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _service.Upload(file, GetVirtualPath());

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadImage")]
        public IActionResult UploadImage([FromBody] UploadImageInputModel data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _service.UploadImage(data, GetVirtualPath());

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        #endregion

        #region Postages

        [HttpPost]
        [Route("")]
        public IActionResult CreatePostage(CreatePostInputModel data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _service.CreatePost(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdatePostage([FromRoute]int id, [FromBody]UpdatePostInputModel data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                data.id = id;
                var result = _service.UpdatePost(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("{id}/{projectKey}")]
        public IActionResult DeletePostage([FromRoute]int id, [FromRoute]string projectKey)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _service.DeletePost(id, projectKey);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("list-postages")]
        public IActionResult ListPostages([FromQuery]ListPostsInputModel data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _service.ListPosts(data, GetVirtualPath());

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("{id}/get-postage")]
        public IActionResult GetPostageById([FromRoute]int id, [FromQuery]GetPostByIdInputModel data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                data.id = id;
                var result = _service.GetPostById(data, GetVirtualPath());

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        #endregion

        #region Customizations

        [HttpGet]
        [Route("hub-veiculos/posts")]
        public IActionResult GetPostsVeiculos([FromQuery]ListPostsInputModel data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var results = _service.ListPosts(data, GetVirtualPath());

                #region Customization
                var comunications = new List<ComunicationViewModel>();
                foreach (var item in results)
                {
                    var comunication = new ComunicationViewModel(
                        item.title,
                        item.content,
                        item.createdAt
                    );

                    var imageURL = item.files.FirstOrDefault(i => i.session == EnumHelpers.GetDescription(FileSessions.title));
                    comunication.imageURL = imageURL == null ? "" : imageURL.name;

                    var optional = item.files.FirstOrDefault(i => i.session == EnumHelpers.GetDescription(FileSessions.optional));
                    if (optional != null)
                    {
                        var extension = $".{optional.name.Split('.')[optional.name.Split('.').Count() - 1]}";
                        if (TypeExtensions.IsVideoExtension(extension))
                            comunication.video = optional.name;
                        else if (TypeExtensions.IsAudioExtension(extension))
                            comunication.audio = optional.name;
                    }

                    comunications.Add(comunication);
                }
                #endregion

                return Ok(comunications);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        #endregion

        #region Privates

        private string GetVirtualPath()
        {
            var prefix = "http://";
            if (Request.IsHttps)
                prefix = "https://";
            return prefix + Request.Host.ToString() + "/fileserver_api/resources";
        }

        #endregion
    }
}
