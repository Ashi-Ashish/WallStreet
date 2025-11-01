import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler";
import type { UserProfileToken } from "../Models/User";
import config from "../config";

const api = config.backendUrl;


export const loginAPI = async (
    userName: string,
    password: string
) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "account/login", {
            userName: userName,
            password: password
        });
        return data;
    } catch (error) {
        handleError(error);
    }
};


export const registerAPI = async (
    userName: string,
    password: string,
    email: string
) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "account/register", {
            userName: userName,
            password: password,
            email: email
        });
        return data;
    } catch (error) {
        handleError(error);
    }
};