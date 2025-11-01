import axios from "axios";
import config from "../config";
import type { PortfolioGet, PortfolioPost } from "../Models/Portfolio";
import { handleError } from "../Helpers/ErrorHandler";

const api = config.backendUrl;

export const portfolioAddAPI = async (symbol: string) => {

    try {
        const data = await axios.post<PortfolioPost>(`${api}?symbol=${symbol}`);
        return data;
    } catch (error) {
        handleError(error);
    }
};

export const portfolioDeleteAPI = async (symbol: string) => {
    try {
        const data = await axios.delete<PortfolioPost>(`${api}portfolio?symbol=${symbol}`);
        return data;
    } catch (error) {
        handleError(error);
    }
};

export const portfolioGetAPI = async () => {
    try {
        const data = await axios.get<PortfolioGet[]>(`${api}portfolio`);
        return data;
    } catch (error) {
        handleError(error);
    }
};