import { ENV } from './../core/env.config';

interface AuthConfig {
  CLIENT_ID: string;
  CLIENT_DOMAIN: string;
  AUDIENCE: string;
  REDIRECT: string;
  SCOPE: string;
};
//тука малко не знам кво става още
export const AUTH_CONFIG: AuthConfig = {
  CLIENT_ID: 'gHAXMUxSR5t0r6MpQAOHlylnoPM2mQrr',
  CLIENT_DOMAIN: 'training-book.eu.auth0.com',
  AUDIENCE: 'http://localhost:5000/api/', // likely https://training-book.eu.auth0.com/userinfo 
  REDIRECT: `${ENV.BASE_URI}/callback`,
  SCOPE: 'openid profile'
};