import { yupResolver } from '@hookform/resolvers/yup';
import logo from "../../assets/wallStreetLogo.jpg";
import * as Yup from 'yup';
import { useForm } from 'react-hook-form';
import { useAuth } from '../../Context/useAuth';

type Props = {}

type LoginFormInput = {
    userName: string
    password: string;
}

const validation = Yup.object().shape({
    userName: Yup.string().required('Username is required'),
    password: Yup.string().required('Password is required')
});

const LoginPage = (props: Props) => {
    const { loginUser } = useAuth();
    const { register, handleSubmit, formState: { errors } } = useForm<LoginFormInput>(
        {
            resolver: yupResolver(validation)
        }
    );

    const handleLogin = (form: LoginFormInput) => {
        loginUser(form.userName, form.password);
    }

    return (
        <>
            {/*
        This example requires updating your template:

        ```
        <html class="h-full bg-white">
        <body class="h-full">
        ```
      */}
            <div className="flex min-h-full flex-col justify-center px-6 py-12 lg:px-8">
                <div className="sm:mx-auto sm:w-full sm:max-w-sm">
                    <img
                        alt="Your Company"
                        src={logo}
                        className="mx-auto h-10 w-auto"
                    />
                    <h2 className="mt-10 text-center text-2xl/9 font-bold tracking-tight text-gray-900">
                        Sign in to your account
                    </h2>
                </div>

                <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
                    <form className="space-y-6" onSubmit={handleSubmit(handleLogin)}>
                        <div>
                            <label htmlFor="UserName" className="block text-sm/6 font-medium text-gray-900">
                                Username
                            </label>
                            <div className="mt-2">
                                <input
                                    id="UserName"
                                    type="text"
                                    required
                                    className="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline-2 focus:-outline-offset-2 focus:outline-gray-600 sm:text-sm/6"
                                    {...register('userName')}
                                />
                                {errors.userName && <p className="mt-2 text-sm text-red-600">{errors.userName.message}</p>}
                            </div>
                        </div>

                        <div>
                            <div className="flex items-center justify-between">
                                <label htmlFor="password" className="block text-sm/6 font-medium text-gray-900">
                                    Password
                                </label>
                                <div className="text-sm">
                                    <a href="#" className="font-semibold text-gray-600 hover:text-gray-500">
                                        Forgot password?
                                    </a>
                                </div>
                            </div>
                            <div className="mt-2">
                                <input
                                    id="password"
                                    type="password"
                                    required
                                    autoComplete="current-password"
                                    className="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline-2 focus:-outline-offset-2 focus:outline-gray-600 sm:text-sm/6"
                                    {...register('password')}
                                />
                                {errors.password && <p className="mt-2 text-sm text-red-600">{errors.password.message}</p>}
                            </div>
                        </div>

                        <div>
                            <button
                                type="submit"
                                className="flex w-full justify-center rounded-md bg-gray-600 px-3 py-1.5 text-sm/6 font-semibold text-white shadow-xs hover:bg-gray-500 focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-gray-600"
                            >
                                Sign in
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </>
    )
}

export default LoginPage