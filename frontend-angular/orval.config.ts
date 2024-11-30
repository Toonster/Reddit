import { defineConfig } from "orval";

export default defineConfig({
  reddit: {
    input: "http://localhost:5292/swagger/v1/swagger.json",
    output: {
      mode: "tags-split",
      prettier: true,
      tsconfig: "./tsconfig.json",
      target: "./reddit.ts",
      workspace: "src/api/",
      client: "angular",
    },
    hooks: {
      afterAllFilesWrite: "prettier --write",
    },
  },
});
