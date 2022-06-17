﻿using BuildingBlocks.Domain.EfCore;
using FileService.Application.Commands;
using FileService.Application.Services;
using FileService.Core.Domain.Aggregates;
using FileService.Core.Domain.Aggregates.Tenant;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Application.CommandHandlers
{
    public class UploadTenantImageCommandHandler : IRequestHandler<UploadTenantImageCommand, TenantImageAsset>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudService _cloudService;
        private readonly IAssetRepository _assetRepository;

        public UploadTenantImageCommandHandler(IUnitOfWork unitOfWork, ICloudService cloudService, IAssetRepository assetRepository)
        {
            _unitOfWork = unitOfWork;
            _cloudService = cloudService;
            _assetRepository = assetRepository;
        }

        public async Task<TenantImageAsset> Handle(UploadTenantImageCommand request, CancellationToken cancellationToken)
        {
            var url = await _cloudService.UploadUserAvatarAsync(request.Folder, request.Image, request.TenantId);

            var asset = new TenantImageAsset(request.TenantId, url, request.AssetType);

            await _assetRepository.AddAsync(asset);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return asset;
        }
    }
}