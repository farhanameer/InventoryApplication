using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using InventoryApplication.DataCon;
using InventoryApplication.Entities;
using InventoryApplication.HelperModels.Cloudinary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InventoryApplication.Controllers
{
    [Route("api/photos")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IOptions<CloudinarySettings> _cloudinarySettings;
        private readonly Cloudinary _cloudinary;
        private readonly DataContext _context;
        public PhotoController(IOptions<CloudinarySettings> cloudinarySettings,DataContext context)
        {
            _cloudinarySettings = cloudinarySettings;
            _context = context;
            Account account = new Account
            {
                ApiKey = _cloudinarySettings.Value.ApiKey,
                ApiSecret = _cloudinarySettings.Value.ApiSecret,
                Cloud = _cloudinarySettings.Value.CloudName
            };

            _cloudinary = new Cloudinary(account);
        }

        [Authorize]
        [HttpGet("{id}",Name ="GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            if (id==0)
            {
                return BadRequest("Please Enter A Valid ID");
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserPhoto photos = await _context.UserPhotos.Where(x => x.UserPhotoID == id && x.UserID == userId).FirstOrDefaultAsync();
            if (photos==null)
            {
                return NotFound("No Photo Was Found");
            }
            return Ok(photos);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPhoto([FromForm]CloudinaryPhoto cloudinaryPhoto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var file = cloudinaryPhoto.File;
            var uploadResult = new ImageUploadResult();
            if (file.Length>0)
            {
                using (var stream=file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            cloudinaryPhoto.Url = uploadResult.Uri.ToString();
            cloudinaryPhoto.PublicID = uploadResult.PublicId;
            UserPhoto userPhoto = new UserPhoto();
            userPhoto.ImgUrl = cloudinaryPhoto.Url;
            userPhoto.PublicID = cloudinaryPhoto.PublicID;
            userPhoto.UserID = userId;
            userPhoto.IsDefault = true;
            await  _context.UserPhotos.AddAsync(userPhoto);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetPhoto", new { id = userPhoto.UserPhotoID }, userPhoto);
        }
    }
}