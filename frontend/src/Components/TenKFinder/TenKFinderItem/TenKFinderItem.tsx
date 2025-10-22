import React from 'react'
import type { CompanyTenK } from '../../../company'
import { Link } from 'react-router';

type Props = {
    tenK: CompanyTenK;
}

const TenKFinderItem = ({ tenK }: Props) => {
    const filingDate = new Date(tenK.filingDate);
    const filingMonth = filingDate.toLocaleString('en-US', { month: 'long' });
    return (
        <Link
            reloadDocument
            to={tenK.finalLink}
            type="button"
            className='inline-flex items-center p-4 text-md text-white bg-gray-900 rounded-md mr-2'>
            {" "} 10-K - {tenK.symbol} - {filingMonth} {" "}
        </Link>
    )
}

export default TenKFinderItem
