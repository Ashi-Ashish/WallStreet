import React, { type JSX } from 'react'
import Card from '../Card/Card'

type Props = {}

const CardList: React.FC<Props> = (props: Props): JSX.Element => {
  return (
    <div>
        <Card companyName='Apple Inc.' ticker='AAPL' price={110} />
        <Card companyName='Samsung' ticker='SSNLF' price={80} />
        <Card companyName='Microsoft' ticker='MSFT' price={300} />
    </div>
  )
}

export default CardList