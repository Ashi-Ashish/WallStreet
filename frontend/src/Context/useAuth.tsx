import type { UserProfile } from "../Models/User";
import { createContext, useContext, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { loginAPI, registerAPI } from "../Services/AuthService";
import { toast } from "react-toastify";
import axios from "axios";

type UserContextType = {
    user: UserProfile | null;
    token: string | null;
    registerUser: (email: string, userName: string, password: string) => void;
    loginUser: (email: string, password: string) => void;
    logoutUser: () => void;
    isLoggedIn: () => boolean;
};

type Props = {
    children: React.ReactNode;
}

const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserProvider = ({ children }: Props) => {
    const navigate = useNavigate();
    const [token, setToken] = useState<string | null>(null);
    const [user, setUser] = useState<UserProfile | null>(null);
    const [isReady, setIsReady] = useState<boolean>(false);

    useEffect(() => {
        const user = localStorage.getItem("user");
        const token = localStorage.getItem("token");
        if (user && token) {
            setUser(JSON.parse(user));
            setToken(token);
            axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
        }
        setIsReady(true);
    }, []);

    const registerUser = async (
        email: string,
        userName: string,
        password: string
    ) => {
        await registerAPI(email, userName, password)
            .then((res) => {
                if (res) {
                    localStorage.setItem("token", res?.data.token);
                    const userObj = {
                        userName: res?.data.userName,
                        email: res?.data.email
                    }
                    localStorage.setItem("user", JSON.stringify(userObj));
                    setToken(res?.data.token!);
                    setUser(userObj!);
                    toast.success("Registration successful!");
                    navigate("/search");
                }
            })
            .catch((error) => {
                toast.warning(error.response.data.message || "Registration failed. Please try again.");
            });
    };

    const loginUser = async (
        userName: string,
        password: string
    ) => {
        await loginAPI(userName, password)
            .then((res) => {
                if (res) {
                    localStorage.setItem("token", res?.data.token);
                    const userObj = {
                        userName: res?.data.userName,
                        email: res?.data.email
                    }
                    localStorage.setItem("user", JSON.stringify(userObj));
                    setToken(res?.data.token!);
                    setUser(userObj!);
                    toast.success("Registration successful!");
                    navigate("/search");
                }
            })
            .catch((error) => {
                toast.warning(error.response.data.message || "Registration failed. Please try again.");
            });
    };

    const logoutUser = () => {
        setUser(null);
        setToken(null);
        localStorage.removeItem("user");
        localStorage.removeItem("token");
        navigate("/");
    };

    const isLoggedIn = () => {
        return !!user;
    };

    return (
        <UserContext.Provider value={{ loginUser, user, token, logoutUser, isLoggedIn, registerUser }}>
            {isReady ? children : null}
        </UserContext.Provider>
    );
}

export const useAuth = () => {
    return useContext(UserContext);
}