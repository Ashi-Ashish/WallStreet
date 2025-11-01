import type { CommentGet } from '../../Models/Comment';
import StockCommentListItem from './StockCommentListItem/StockCommentListItem';

type Props = {
    comments: CommentGet[];
}

const StockCommentList = ({ comments }: Props) => {
    if (!comments.length) {
        return (
            <div className="flex flex-col items-center justify-center gap-2 rounded-xl border border-dashed border-gray-200 bg-gray-50 px-6 py-10 text-center text-sm text-gray-500 dark:border-gray-700 dark:bg-gray-800/50 dark:text-gray-400">
                <span className="font-medium text-gray-600 dark:text-gray-300">No comments yet</span>
                <span>Be the first to share an insight about this stock.</span>
            </div>
        );
    }

    return (
        <ul className="space-y-4">
            {comments.map((comment, index) => (
                <li key={`${comment.title}-${comment.createdBy}-${index}`}>
                    <StockCommentListItem comment={comment} />
                </li>
            ))}
        </ul>
    )
}

export default StockCommentList
