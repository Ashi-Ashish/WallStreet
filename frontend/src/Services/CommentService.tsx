import axios from "axios";
import type { CommentPost } from "../Models/Comment";
import { handleError } from "../Helpers/ErrorHandler";
import config from "../config";

const url = config.backendUrl;

export const commentPostAPI = async (title: string, content: string, stockSymbol: string) => {
    try {
        const data = await axios.post<CommentPost>(`${url}comment/${stockSymbol}`, {
            title: title,
            content: content,
        });
        return data;
    } catch (error) {
        handleError(error);
    }
};