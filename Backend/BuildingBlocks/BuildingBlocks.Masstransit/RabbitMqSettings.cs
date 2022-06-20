﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Masstransit
{
    public class RabbitMqSettings
    {
        // generall
        public const string Host = "localhost";
        public const string VirtualHost = "/";
        public const string Username = "guest";
        public const string Password = "guest";

        // saga
        public const string OrderSagaName = "order_service_saga";
        public const string OrderSagaCatalogConsumerEndpointName = "order_service_saga_catalog_consumer";
        public const string OrderSagaPaymentConsumerEndpointName = "order_service_saga_payment_consumer";
        public const string OrderSagaTenantConsumerEndpointName = "order_service_saga_tenant_consumer";
        public const string OrderSagaDeliveryConsumerEndpointName = "order_service_saga_delivery_consumer";
        public const string OrderSagaBasketCheckoutConsumerEndpointName = "order_service_saga_basket_checkout_consumer";

        // file upload
        public const string FileUploadCategoryImageConsumerEndpointName = "catalog_service_category_image_consumer";
        public const string FileUploadCategoryVideoConsumerEndpointName = "catalog_service_category_video_consumer";
        public const string FileUploadProductImageConsumerEndpointName = "catalog_service_product_image_consumer";
        public const string FileUploadProductVideoConsumerEndpointName = "catalog_service_product_video_consumer";
        public const string FileUploadSetImageConsumerEndpointName = "catalog_service_set_image_consumer";
        public const string FileUploadSetVideoConsumerEndpointName = "catalog_service_set_video_consumer";

        public const string FileUploadAvatarImageConsumerEndpointName = "catalog_service_avatar_image_consumer";


        public const string RabbitMqUri = "rabbitmq://localhost";
        public const string MediaCatalogQueue = "queue:media-catalog-queue";

    }
}