import StockCommentForm from './StockCommentForm/StockCommentForm';
import { commentPostAPI } from '../../Services/CommentService';
import { toast } from 'react-toastify';

type Props = {
    stockSymbol: string;
}

type CommentFormInputs = {
    title: string;
    content: string;
};

const StockComment = ({ stockSymbol }: Props) => {
    const handleComment = (e: CommentFormInputs) => {
        commentPostAPI(e.title, e.content, stockSymbol)
            .then((res) => {
                if (res) {
                    toast.success("Comment posted successfully!");
                } else {
                    toast.error("Failed to post comment. Please try again.");
                }
            })
            .catch((error) => {
                toast.warning(error.response.data.message || "An error occurred. Please try again.");
            });
    }
    return (
        <StockCommentForm stockSymbol={stockSymbol} handleComment={handleComment} />
    )
}

export default StockComment