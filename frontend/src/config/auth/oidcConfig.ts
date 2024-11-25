import { AuthProviderProps } from "react-oidc-context";

export const oidcConfig: AuthProviderProps = {
  client_id: import.meta.env.VITE_CLIENT_ID,
  authority: import.meta.env.VITE_AUTHORITY,
  redirect_uri: `${window.location.origin}/auth/`,
};
