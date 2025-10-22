# WallStreet Frontend

WallStreet is a Vite + React + TypeScript interface for researching public companies with data from the [Financial Modeling Prep](https://financialmodelingprep.com/developer/docs/) (FMP) API. The app ships with reusable portfolio, company comparison, and filing finder components backed by a typed API client.

## Feature Highlights
- Search and detail pages powered by the FMP API (`src/api.tsx`) with shared types in `src/company.d.ts`.
- Modular dashboards: Comp Finder, 10-K finder, ratio tiles, and portfolio management components.
- Nested routing via `react-router-dom` (`src/Routes/Routes.tsx`) for company sub-pages.
- Tailwind CSS v4 (via `@tailwindcss/vite`) with project-wide design tokens defined in `src/index.css`.

## Prerequisites
- Node.js 18.18+ (developed with Node 20).
- An FMP API key with access to the stable endpoints used in this project.

## Getting Started
1. Install dependencies (run from the repository root):
   ```bash
   cd frontend
   npm install
   ```
2. Create a `.env` file next to `package.json` and add your credentials:
   ```bash
   VITE_REACT_APP_API_KEY=your_fmp_api_key
   ```
3. Start the development server:
   ```bash
   npm run dev
   ```
4. Open the URL shown in the terminal (defaults to http://localhost:5173) to browse the UI. The `/design-guide` route showcases individual components in isolation.

## Environment Variables
- `VITE_REACT_APP_API_KEY` (required): Financial Modeling Prep API key. Requests fall back to the stable base URL defined in `src/config.ts`; modify that file if you need to point to a different environment.

## Available Scripts
- `npm run dev` – start the Vite dev server with hot module replacement.
- `npm run build` – run `tsc -b` followed by `vite build` to emit a production bundle.
- `npm run preview` – serve the production bundle locally for smoke testing.
- `npm run lint` – lint the project using the shared ESLint flat config.

## Project Structure
```
frontend/
├── public/                     # Static assets served as-is by Vite
├── src/
│   ├── Components/             # Reusable UI (CompFinder, TenKFinder, Portfolio, etc.)
│   ├── Helpers/                # Number formatting utilities and other helpers
│   ├── Pages/                  # Routed pages composing the dashboard
│   ├── Routes/Routes.tsx       # Central router definition
│   ├── api.tsx                 # Axios client + typed FMP endpoints
│   ├── company.d.ts            # Shared TypeScript types for API responses
│   ├── config.ts               # API configuration (base URL + key access)
│   └── main.tsx                # React application entry point
├── eslint.config.js            # ESLint flat config
├── tsconfig*.json              # TypeScript build and tooling configs
└── vite.config.ts              # Vite configuration
```

## Troubleshooting
- FMP API errors are logged to the console; double-check that the key in `.env` matches your account.
- Vite caches can be cleared by deleting the `.vite` directory if you encounter stale asset issues.

## License

This project is licensed under the terms of the MIT License. See the root `LICENSE` file for details.
