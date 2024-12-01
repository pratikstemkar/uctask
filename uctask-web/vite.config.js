import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import path from "path";

const currentDir = new URL(".", import.meta.url).pathname;

// https://vite.dev/config/
export default defineConfig({
    plugins: [react()],
    resolve: {
        alias: {
            "@": path.resolve(currentDir, "./src"),
        },
    },
});
