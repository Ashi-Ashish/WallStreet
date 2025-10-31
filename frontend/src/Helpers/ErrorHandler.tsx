import axios from "axios";
import { toast } from "react-toastify";

export const handleError = (error: any) => {
    if (axios.isAxiosError(error)) {
        var err = error.response;
        if (Array.isArray(err?.data.errors)) {
            for (let val of err.data.errors) {
                toast.warning(val.description);
            }
        } else if (typeof err?.data.errors === "object") {
            for (let key in err.data.errors) {
                toast.warning(err.data.errors[key]);
            }
        } else if (err?.data) {
            toast.error(err.data);
        } else if (err?.status == 401) {
            window.history.pushState({}, "LoginPage", "/login");
        } else if (err) {
            toast.warning(err.data);
        }
    }
};