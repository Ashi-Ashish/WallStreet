import type { CommentGet } from '../../../Models/Comment'

type Props = {
    comment: CommentGet;
}

const StockCommentListItem = ({ comment }: Props) => {
    const rawInitial = (comment.createdBy || "").trim().charAt(0);
    const authorInitial = rawInitial ? rawInitial.toUpperCase() : "?";
    const authorName = (comment.createdBy || "Anonymous").trim() || "Anonymous";

    return (
        <article className="group relative overflow-hidden rounded-xl border border-gray-200 bg-gradient-to-br from-white via-white to-gray-50 p-5 shadow-sm transition-all duration-200 hover:-translate-y-0.5 hover:border-gray-300 hover:shadow-md dark:border-gray-800 dark:from-gray-900 dark:via-gray-900 dark:to-gray-950">
            <div className="flex items-start gap-4">
                <div className="flex h-12 w-12 shrink-0 items-center justify-center rounded-full bg-gray-900/5 text-sm font-semibold uppercase text-gray-600 shadow-sm dark:bg-gray-700/50 dark:text-gray-100">
                    {authorInitial}
                </div>
                <div className="min-w-0 flex-1">
                    <div className="flex flex-wrap items-baseline justify-between gap-2">
                        <h4 className="text-base font-semibold text-gray-900 dark:text-gray-100">{comment.title}</h4>
                        <span className="text-xs font-medium uppercase tracking-wide text-gray-400 dark:text-gray-500">
                            by {authorName}
                        </span>
                    </div>
                    <p className="mt-2 text-sm leading-relaxed text-gray-600 dark:text-gray-300 whitespace-pre-line">
                        {comment.content}
                    </p>
                </div>
            </div>
        </article>
    )
}

export default StockCommentListItem
