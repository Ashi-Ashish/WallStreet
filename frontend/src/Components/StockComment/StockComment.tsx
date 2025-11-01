import StockCommentForm from './StockCommentForm/StockCommentForm';
import { commentGetAPI, commentPostAPI } from '../../Services/CommentService';
import { toast } from 'react-toastify';
import { useEffect, useState } from 'react';
import type { CommentGet } from '../../Models/Comment';
import Spinner from '../Spinner/Spinner';
import StockCommentList from '../StockCommentList/StockCommentList';

type Props = {
    stockSymbol: string;
}

type CommentFormInputs = {
    title: string;
    content: string;
};

const StockComment = ({ stockSymbol }: Props) => {

    const [comments, setComments] = useState<CommentGet[] | null>(null);
    const [loading, setLoading] = useState<boolean>(false);

    useEffect(() => {
        getComments();
    }, [stockSymbol]);

    const handleComment = (e: CommentFormInputs) => {
        commentPostAPI(e.title, e.content, stockSymbol)
            .then((res) => {
                if (res) {
                    toast.success("Comment posted successfully!");
                    getComments();
                } else {
                    toast.error("Failed to post comment. Please try again.");
                }
            })
            .catch((error) => {
                toast.warning(error.response.data.message || "An error occurred. Please try again.");
            });
    };

    const getComments = () => {
        setLoading(true);
        commentGetAPI(stockSymbol)
            .then((res) => {
                if (res) {
                    setLoading(false);
                    setComments(res.data!);
                } else {
                    toast.error("Failed to fetch comments. Please try again.");
                }
            })
            .catch((error) => {
                toast.warning(error.response.data.message || "An error occurred. Please try again.");
            })
            .finally(() => {
                setLoading(false);
            });
    };

    const commentCount = comments?.length ?? 0;

    return (
        <section className="w-full max-w-3xl mx-auto my-8 space-y-6">
            <div className="overflow-hidden rounded-2xl border border-gray-200 bg-white shadow-sm dark:border-gray-800 dark:bg-gray-900">
                <header className="flex flex-wrap items-center justify-between gap-3 border-b border-gray-200 px-6 py-4 dark:border-gray-800">
                    <div>
                        <h3 className="text-lg font-semibold text-gray-900 dark:text-white">Community discussion</h3>
                        <p className="text-sm text-gray-500 dark:text-gray-400">
                            Share your perspective on {stockSymbol} and explore what others think.
                        </p>
                    </div>
                    <span className="inline-flex items-center rounded-full border border-gray-200 px-3 py-1 text-xs font-semibold uppercase tracking-wide text-gray-600 dark:border-gray-700 dark:text-gray-300">
                        {commentCount} comment{commentCount === 1 ? "" : "s"}
                    </span>
                </header>

                <div className="px-6 py-5">
                    {loading ? (
                        <div className="flex w-full justify-center py-10">
                            <Spinner />
                        </div>
                    ) : (
                        <StockCommentList comments={comments || []} />
                    )}
                </div>
            </div>

            <StockCommentForm stockSymbol={stockSymbol} handleComment={handleComment} />
        </section>
    )
}

export default StockComment
