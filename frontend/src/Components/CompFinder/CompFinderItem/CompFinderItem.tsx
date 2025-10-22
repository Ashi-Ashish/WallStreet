import React from 'react'
import { Link } from 'react-router-dom';

type Props = {
    ticker: string;
}

const CompFinderItem = ({ ticker }: Props) => {
    return (
        <Link
            reloadDocument
            to={`/company/${ticker}/company-profile`}
            type="button"
            className='inline-flex items-center p-4 text-md text-white bg-gray-900 rounded-md mr-2'
        >
            {" "}{ticker}{" "}
        </Link>
    )
}

export default CompFinderItem