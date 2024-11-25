import axios from "axios";
import { User } from "oidc-client-ts";
import { QueryClient } from "@tanstack/react-query";

export const redditClient = axios.create({
  baseURL: import.meta.env.REDDIT_URL,
  timeout: 1000,
});

redditClient.interceptors.response.use((config) => {
  const oidcStorage = localStorage.getItem(`oidc.user:${import.meta.env.VITE_AUTHORITY}:${import.meta.env.VITE_CLIENT_ID}`);
  if (config.headers && oidcStorage) {
    const token = User.fromStorageString(oidcStorage).access_token;
    config.headers["Authorization"] = `Bearer ${token}`;
  }

  return config;
});

export const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      staleTime: 0,
      gcTime: 0,
      retry: false,
    },
  },
});
