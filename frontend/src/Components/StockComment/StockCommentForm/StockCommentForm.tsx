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
        <div className="max-w-2xl mx-auto p-4 bg-white rounded-lg shadow-sm">
            <h3 className="text-lg font-semibold mb-3">Comment on {stockSymbol}</h3>
            <form
                onSubmit={handleSubmit((handleComment))}
                className="space-y-4"
            >
                <div>
                    <label htmlFor="title" className="block text-sm font-medium text-gray-700 mb-1">
                        Title
                    </label>
                    <input
                        id="title"
                        {...register("title")}
                        placeholder="Brief summary"
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-gray-500 focus:border-transparent"
                    />
                    {errors.title?.message && (
                        <p className="mt-1 text-sm text-red-600">{errors.title.message as string}</p>
                    )}
                </div>

                <div>
                    <label htmlFor="content" className="block text-sm font-medium text-gray-700 mb-1">
                        Content
                    </label>
                    <textarea
                        id="content"
                        {...register("content")}
                        rows={6}
                        placeholder="Share your thoughts about this stock..."
                        className="w-full px-3 py-2 border rounded-md resize-vertical focus:outline-none focus:ring-2 focus:ring-gray-500 focus:border-transparent"
                    />
                    {errors.content?.message && (
                        <p className="mt-1 text-sm text-red-600">{errors.content.message as string}</p>
                    )}
                </div>

                <div className="flex items-center justify-between">
                    <button
                        type="submit"
                        className="inline-flex items-center px-4 py-2 bg-gray-600 text-white text-sm font-medium rounded-md hover:bg-gray-700 focus:outline-none focus:ring-2 focus:ring-gray-500"
                    >
                        Post Comment
                    </button>
                    <span className="text-xs text-gray-500">Minimum 10 characters · Max 2000</span>
                </div>
            </form>
        </div>
    )
}

export default StockCommentForm