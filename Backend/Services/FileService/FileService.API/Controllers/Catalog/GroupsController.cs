﻿using AutoMapper;
using FileService.Application.Commands;
using FileService.Application.Queries;
using FileService.Contracts.v1.Contracts;
using FileService.Contracts.v1.Events;
using FileService.Core.Domain;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.API.Controllers.Catalog
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public GroupsController(IMediator mediator, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        [Route("upload-image")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AssetResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadGroupImageAsync([FromForm, Required] UploadGroupImageRequest request)
        {
            var command = new UploadImageCommand
            {
                Folder = "group_images",
                Description = request.Description,
                Title = request.Title,
                Tags = request.Tags,
                ExternalEntityId = request.ExternalEntityId,
                Image = request.Image,
                AssetType = AssetType.CatalogGroupImage,
            };

            var data = await _mediator.Send(command);

            await _publishEndpoint.Publish(new GroupImageUploadResponseEvent(data.ExternalEntityId, data.Id));
            var result = _mapper.Map<AssetResponse>(data);
            return Ok(result);
        }


        [HttpPost]
        [Route("upload-video")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AssetResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadGroupVideoAsync([FromForm, Required] UploadGroupVideoRequest request)
        {
            var command = new UploadVideoCommand
            {
                Folder = "group_videos",
                Description = request.Description,
                Title = request.Title,
                Tags = request.Tags,
                ExternalEntityId = request.ExternalEntityId,
                Video = request.Video,
                AssetType = AssetType.CatalogGroupVideo,
            };

            var data = await _mediator.Send(command);

            await _publishEndpoint.Publish(new GroupVideoUploadResponseEvent(data.ExternalEntityId, data.Id));
            var result = _mapper.Map<AssetResponse>(data);
            return Ok(result);
        }


        [HttpGet]
        [Route("{externalentityid:guid}/list-assets")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<AssetResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListGroupAssetsAsync([FromRoute, Required] Guid externalEntityId)
        {
            var query = new ListAssetsQuery
            {
                ExternalEntityId = externalEntityId
            };

            var data = await _mediator.Send(query);

            return Ok(_mapper.Map<IReadOnlyCollection<AssetResponse>>(data));
        }


        [HttpGet]
        [Route("{assetid:guid}/find-asset")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AssetResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindGroupAssetAsync([FromRoute, Required] Guid assetId)
        {
            var query = new FindAssetQuery
            {
                AssetId = assetId
            };

            var data = await _mediator.Send(query);
            return Ok(_mapper.Map<AssetResponse>(data));
        }


        [HttpPatch]
        [Route("{assetid:guid}/change-description")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AssetResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchGroupDescriptionAsync([FromRoute, Required] Guid assetId, [FromBody, Required] PatchGroupImageDescriptionRequest request)
        {
            var command = new PatchAssetDescriptionCommand
            {
                AssetId = assetId,
                Title = request.Title,
                Description = request.Description,
                Tags = request.Tags
            };

            var data = await _mediator.Send(command);
            return Ok(_mapper.Map<AssetResponse>(data));
        }
    }
}