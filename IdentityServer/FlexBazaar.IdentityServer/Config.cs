// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace FlexBazaar.IdentityServer
{
    public static class Config
    {
        // bu kısımda her mikroservise erişim için bir key tanımlanır
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
       {
           new ApiResource("ResourceCatalog"){ 
               Scopes = { "CatalogFullPermission", "CatalogReadPermission"} 
           },
           new ApiResource("ResourceDiscount"){
               Scopes = { "DiscountFullPermission"}
           },
           new ApiResource("ResourceOrder"){
               Scopes = { "OrderFullPermission"}
           },
       };
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission", "Read authority for catalog operations"),
            new ApiScope("DiscountFullPermission", "Full authority for discount operations"),
            new ApiScope("OrderFullPermission", "Full authority for order operations")
        };
        public static IEnumerable<Client> Clients => new Client[]
        {

            // visitor 
            new Client
            {
                ClientId = "FlexBazaarVisitorId",
                ClientName = "Flex Bazaar Client User",
                // kimlik işlemleri için kullanılacak property
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("flexbazaarsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission"}
            },

            // Manager
            new Client
            {
                ClientId = "FlexBazaarManagerId",
                ClientName = "Flex Bazaar Manager User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("flexbazaarsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission"}
            },

            //Admin
            new Client
            {
                ClientId = "FlexBazaarAdminId",
                ClientName = "Flex Bazaar Admin User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("flexbazaarsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 600
            }
        };
    }
}