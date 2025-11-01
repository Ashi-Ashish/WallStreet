import * as Yup from "yup";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";

type Props = {
    stockSymbol: string;
    handleComment: (e: CommentFormInputs) => void;
};

type CommentFormInputs = {
    title: string;
    content: string;
};

const validation = Yup.object().shape({
    title: Yup.string()
        .required("Title is required")
        .max(100, "Title must be at most 100 characters"),
    content: Yup.string()
        .required("Content is required")
        .min(10, "Content must be at least 10 characters")
        .max(2000, "Content must be at most 2000 characters"),
});

const StockCommentForm = ({ stockSymbol, handleComment }: Props) => {
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<CommentFormInputs>({ resolver: yupResolver(validation) });
    return (
        <div className="w-full overflow-hidden rounded-2xl border border-gray-200 bg-white shadow-sm dark:border-gray-800 dark:bg-gray-900">
            <div className="border-b border-gray-200 bg-gray-50/70 px-6 py-4 dark:border-gray-800 dark:bg-gray-900/40">
                <h3 className="text-lg font-semibold text-gray-900 dark:text-white">Add your comment</h3>
                <p className="text-sm text-gray-500 dark:text-gray-400">
                    Join the conversation about {stockSymbol} and keep it constructive.
                </p>
            </div>
            <form
                onSubmit={handleSubmit(handleComment)}
                className="space-y-5 px-6 py-5"
            >
                <div className="space-y-2">
                    <label htmlFor="title" className="block text-sm font-semibold text-gray-700 dark:text-gray-200">
                        Title
                    </label>
                    <input
                        id="title"
                        {...register("title")}
                        placeholder="Give your comment a clear headline"
                        className="w-full rounded-xl border border-gray-200 bg-gray-50/80 px-4 py-2.5 text-sm text-gray-700 placeholder:text-gray-400 transition focus:border-gray-400 focus:bg-white focus:outline-none focus:ring-2 focus:ring-gray-400/60 dark:border-gray-700 dark:bg-gray-800 dark:text-gray-100 dark:placeholder:text-gray-500 dark:focus:border-gray-500 dark:focus:ring-gray-500/40"
                    />
                    {errors.title?.message && (
                        <p className="text-sm text-red-500">{errors.title.message as string}</p>
                    )}
                </div>

                <div className="space-y-2">
                    <label htmlFor="content" className="block text-sm font-semibold text-gray-700 dark:text-gray-200">
                        Content
                    </label>
                    <textarea
                        id="content"
                        {...register("content")}
                        rows={6}
                        placeholder="Share your perspective, insights, or questions..."
                        className="w-full min-h-[160px] rounded-xl border border-gray-200 bg-gray-50/80 px-4 py-3 text-sm text-gray-700 placeholder:text-gray-400 transition focus:border-gray-400 focus:bg-white focus:outline-none focus:ring-2 focus:ring-gray-400/60 dark:border-gray-700 dark:bg-gray-800 dark:text-gray-100 dark:placeholder:text-gray-500 dark:focus:border-gray-500 dark:focus:ring-gray-500/40"
                    />
                    {errors.content?.message && (
                        <p className="text-sm text-red-500">{errors.content.message as string}</p>
                    )}
                </div>

                <div className="flex flex-wrap items-center justify-between gap-3">
                    <span className="text-xs text-gray-400 dark:text-gray-500">
                        Minimum 10 characters · Max 2000
                    </span>
                    <button
                        type="submit"
                        className="inline-flex items-center justify-center rounded-full bg-gray-900 px-5 py-2.5 text-sm font-semibold text-white shadow-sm transition duration-200 hover:bg-black focus:outline-none focus:ring-2 focus:ring-gray-500/60 focus:ring-offset-2 focus:ring-offset-white dark:bg-gray-100 dark:text-gray-900 dark:hover:bg-white dark:focus:ring-gray-300 dark:focus:ring-offset-gray-900"
                    >
                        Post comment
                    </button>
                </div>
            </form>
        </div>
    )
}

export default StockCommentForm
