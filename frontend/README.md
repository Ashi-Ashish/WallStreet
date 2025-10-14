# WallStreet Frontend

WallStreet is a Vite + React + TypeScript interface for exploring public companies and their market data. It provides reusable UI components for company snapshots and typed helpers for calling the [Financial Modeling Prep](https://financialmodelingprep.com/developer/docs/) API.

## Features
- Search bar component ready to power symbol lookup flows.
- Company card components for highlighting key details.
- Strongly typed API client (`src/api.tsx`) built with Axios.
- Configuration-driven API base URL and key management (`src/config.ts`).

## Tech Stack
- React 19 with TypeScript for typed UI development.
- Vite 7 for rapid builds and HMR.
- Axios for REST requests.
- ESLint with the flat config for linting.

## Getting Started
1. Install dependencies:
   ```bash
   npm install
   ```
2. Add a `.env` file with your Financial Modeling Prep key:
   ```bash
   VITE_REACT_APP_API_KEY=your_api_key
   ```
3. Launch the dev server:
   ```bash
   npm run dev
   ```
4. Open the URL shown in the terminal (defaults to http://localhost:5173).

## Available Scripts
- `npm run dev` – start the Vite dev server with HMR.
- `npm run build` – run the TypeScript project references build and bundle for production.
- `npm run preview` – serve the production build locally.
- `npm run lint` – lint the codebase with ESLint.

## Project Structure
```
frontend/
├── public/             # Static assets served as-is
├── src/
│   ├── Components/     # Reusable UI components (cards, search, etc.)
│   ├── api.tsx         # Financial Modeling Prep API helper
│   ├── config.ts       # API base URL and key wiring
│   ├── company.d.ts    # Shared TypeScript types for company data
│   └── main.tsx        # React entry point
└── vite.config.ts      # Vite configuration
```

## Next Steps
- Wire the search form to `searchCompanies` to display live results.
- Expand card data with metrics from `company.d.ts`.
- Add automated tests for API helpers and components.

## License

This project is licensed under the terms of the MIT License. See the root `LICENSE` file for details.
