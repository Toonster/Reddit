module.exports = {
  root: true,
  parser: "@typescript-eslint/parser",
  parserOptions: { project: "tsconfig.json" },
  ignorePatterns: [".eslintrc.cjs", "vite.config.ts", "**/lib/typings/*.ts"],
  extends: ["eslint:recommended", "plugin:@typescript-eslint/recommended", "eslint-config-prettier", "prettier"],
  settings: {
    react: {
      version: "detect",
    },
    "import/resolver": {
      alias: {
        map: [["", "./public"]],
      },
      node: {
        paths: ["src"],
        extensions: [".js", ".ts"],
      },
    },
  },
  plugins: [],
  rules: {
    // Add your own rules here to override ones from the extended configs.
    "max-len": ["error", { code: 250 }],
    "arrow-body-style": ["error", "as-needed"],
    "no-await-in-loop": "error",
    "no-return-await": "error",
    "require-await": "error",
    "no-console": "error",
    "@typescript-eslint/no-unused-vars": ["error"],
  },
};
