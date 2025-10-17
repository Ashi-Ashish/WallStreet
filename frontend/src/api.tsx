import axios from "axios"
import type { CompanyProfile, CompanySearch } from "./company";
import config from "./config";

interface SearchResponse {
    data: CompanySearch[]
}

export const searchCompanies = async (query: string) => {
    try {
        const data = await axios.get<SearchResponse>(`${config.apiBaseUrl}/search-symbol?query=${query}&limit=10&exchange=NASDAQ&apikey=${config.apiKey}`);
        return data;

    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error('error message:', error.message);
            return error.message;
        } else {
            console.error('unexpected error:', error);
            return 'An unexpected error occurred';
        }
    }
}

export const getCompanyProfile = async (symbol: string) => {
    try {
        const data = await axios.get<CompanyProfile[]>(`${config.apiBaseUrl}/profile?symbol=${symbol}&apikey=${config.apiKey}`)
        return data;
    } catch (error: any) {
        console.log("error message from API:", error.message);
    }
}