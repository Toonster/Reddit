import { LogLevel, PassedInitialConfig } from "angular-auth-oidc-client";
import { environment } from "../../environments/environment";

export const authConfig: PassedInitialConfig = {
  config: {
    authority: environment.authority,
    authWellknownEndpointUrl: "https://login.microsoftonline.com/common/v2.0",
    redirectUrl: `${window.location.origin}/auth/`,
    clientId: environment.clientId,
    scope: "openid profile offline_access https://redditpoc.onmicrosoft.com/reddit-poc-api1/posts.write https://redditpoc.onmicrosoft.com/reddit-poc-api1/posts.read",
    responseType: "code",
    silentRenew: true,
    useRefreshToken: true,
    maxIdTokenIatOffsetAllowedInSeconds: 600,
    issValidationOff: false,
    autoUserInfo: true,
    logLevel: LogLevel.Debug,
  },
};
