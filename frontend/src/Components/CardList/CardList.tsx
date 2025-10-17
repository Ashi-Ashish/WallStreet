import { type FC, type JSX, type SyntheticEvent } from "react";
import Card from "../Card/Card";
import type { CompanySearch } from "../../company";
import { v4 } from "uuid";

interface Props {
  searchResult: CompanySearch[];
  onPortfolioCreate: (e: SyntheticEvent) => void;
};

const CardList: FC<Props> = ({
  searchResult,
  onPortfolioCreate,
}: Props): JSX.Element => {
  return (
    <>
      {searchResult.length > 0 ? (
        searchResult.map((result) => {
          return (
            <Card
              id={result.symbol}
              key={v4()}
              searchResult={result}
              onPortfolioCreate={onPortfolioCreate}
            />
          );
        })
      ) : (
        <p className="my-3 text-xl md:text-2xl font-semibold text-center">
          No results!
        </p>
      )}
    </>
  );
};

export default CardList;
