import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App";
import { AuthProvider } from "react-oidc-context";
import { oidcConfig } from "./config/auth/oidcConfig";
import { QueryClientProvider } from "@tanstack/react-query";
import { queryClient } from "./config/web/http";

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <QueryClientProvider client={queryClient}>
      <AuthProvider {...oidcConfig}>
        <App />
      </AuthProvider>
    </QueryClientProvider>
  </StrictMode>,
);
