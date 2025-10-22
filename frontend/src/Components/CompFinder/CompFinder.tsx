import React, { useEffect, useState } from 'react'
import type { CompanyCompData } from '../../company';
import { getCompData } from '../../api';
import CompFinderItem from './CompFinderItem/CompFinderItem';

type Props = {
    ticker: string;
}

const CompFinder = ({ ticker }: Props) => {

    const [compData, setCompData] = useState<CompanyCompData[]>();
    useEffect(() => {
        const fetchCompData = async () => {
            const value = await getCompData(ticker);
            setCompData(value?.data);
        };
        fetchCompData();
    }, [ticker]);
    return (
        <div className='inline-flex rounded-md shadow-sm m-4'>
            {compData?.map((comp) => {
                return (
                    <CompFinderItem ticker={comp.symbol} key={comp.symbol} />
                );
            })}
        </div>
    )
}

export default CompFinder