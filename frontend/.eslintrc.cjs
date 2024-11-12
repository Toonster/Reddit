module.exports = {
  root: true,
  parser: "@typescript-eslint/parser",
  parserOptions: { project: "tsconfig.json" },
  ignorePatterns: [".eslintrc.cjs", "vite.config.ts", "**/lib/typings/*.ts"],
  extends: [
    "eslint:recommended",
    "plugin:react/recommended",
    "plugin:import/recommended",
    "plugin:@typescript-eslint/recommended",
    "plugin:import/typescript",
    "plugin:react-hooks/recommended",
    "plugin:react/jsx-runtime",
    "plugin:react-hook-form/recommended",
    "plugin:@tanstack/eslint-plugin-query/recommended",
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
        extensions: [".js", ".jsx", ".ts", ".tsx"],
      },
    },
  },
  plugins: [],
  rules: {
    // Add your own rules here to override ones from the extended configs.
    "max-len": ["error", { code: 250 }],
    "react/react-in-jsx-scope": "off",
    "react-hooks/exhaustive-deps": "error",
    "arrow-body-style": ["error", "as-needed"],
    "react/no-danger": "error",
    "react/jsx-no-constructed-context-values": "error",
    "no-await-in-loop": "error",
    "no-return-await": "error",
    "require-await": "error",
    "@typescript-eslint/no-floating-promises": "error",
    "react/no-array-index-key": "warn",
    "react/no-unstable-nested-components": ["error", { allowAsProps: true }],
    "no-console": "error",
    "@typescript-eslint/no-unused-vars": ["error"],
  },
};
