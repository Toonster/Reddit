import { defineConfig } from "orval";

export default defineConfig({
  reddit: {
    input: "http://localhost:5292",
    output: {
      mode: "tags-split",
      prettier: true,
      tsconfig: "./tsconfig.json",
      target: "./reddit.ts",
      client: "angular",
    },
    hooks: {
      afterAllFilesWrite: "prettier --write",
    },
  },
});
