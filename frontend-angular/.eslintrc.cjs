module.exports = {
  root: true,
  parser: "@typescript-eslint/parser",
  parserOptions: { project: "tsconfig.json" },
  ignorePatterns: [".eslintrc.cjs", "vite.config.ts", "**/lib/typings/*.ts"],
  extends: [
    "eslint:recommended",
    "plugin:import/recommended",
    "plugin:@typescript-eslint/recommended",
    "plugin:import/typescript",
    "plugin:promise/recommended",
    "eslint-config-prettier",
    "prettier",
    "plugin:import/typescript",
  ],
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
        extensions: [".js", ".jsx", ".ts"],
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
    "@typescript-eslint/no-floating-promises": "error",
    "no-console": "error",
    "@typescript-eslint/no-unused-vars": ["error"],
  },
};
