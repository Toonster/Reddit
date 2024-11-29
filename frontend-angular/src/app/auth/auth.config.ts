import { PassedInitialConfig } from "angular-auth-oidc-client";
import { environment } from "../../environments/environment";

export const authConfig: PassedInitialConfig = {
  config: {
    authority: environment.authority,
    authWellknownEndpointUrl: "https://login.microsoftonline.com/common/v2.0",
    redirectUrl: `${window.location.origin}/callback`,
    clientId: environment.clientId,
    scope: "openid profile offline_access posts.read posts.write", // 'openid profile offline_access ' + your scopes
    responseType: "code",
    silentRenew: true,
    useRefreshToken: true,
    maxIdTokenIatOffsetAllowedInSeconds: 600,
    issValidationOff: false,
    autoUserInfo: false,
  },
};
