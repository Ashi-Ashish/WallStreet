import { ClipLoader } from 'react-spinners'
import './Spinner.css'

type Props = {
    isLoading?: boolean
}

const Spinner = ({ isLoading = true }: Props) => {
    return (
        <div id='loading-spinner'>
            <ClipLoader
                loading={isLoading}
                size={35}
                aria-label="Loading Spinner"
                data-testid="loader"
                color="#36d7b7"
            />
        </div>
    )
}

export default Spinner