import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'FiratManagementSystemApi',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44331/',
    redirectUri: baseUrl,
    clientId: 'FiratManagementSystemApi_App',
    responseType: 'code',
    scope: 'offline_access FiratManagementSystemApi',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44331',
      rootNamespace: 'FiratManagementSystemApi',
    },
    FiratManagementSystemApi: {
      url: 'https://localhost:44393',
      rootNamespace: 'FiratManagementSystemApi',
    },
  },
} as Environment;
