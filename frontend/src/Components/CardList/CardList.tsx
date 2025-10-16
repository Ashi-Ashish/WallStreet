import React, { type JSX, type SyntheticEvent } from 'react'
import Card from '../Card/Card'
import type { CompanySearch } from '../../company'
import { v4 } from 'uuid';

type Props = {
  searchResult: CompanySearch[];
  onPortfolioCreate: (e: SyntheticEvent) => void;
}

const CardList: React.FC<Props> = ({ searchResult, onPortfolioCreate }: Props): JSX.Element => {
  return (
    <>
      {searchResult.length > 0 ? (
        searchResult.map((result) => {
          return <Card id={result.symbol} key={v4()} searchResult={result} onPortfolioCreate={onPortfolioCreate} />
        })
      ) : (
        <h1>No Results Found</h1>
      )}
    </>
  )
}

export default CardList