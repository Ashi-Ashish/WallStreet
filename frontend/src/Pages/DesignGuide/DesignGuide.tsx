import RatioList from "../../Components/RatioList/RatioList"
import Table from "../../Components/Table/Table"
import { testIncomeStatementData } from "../../Components/Table/testData";

type Props = {}

const tableConfig = [
    {
        label: "Market Cap",
        render: (company: any) => company.marketCapTTM,
        subTitle: "Total value of all a company's shares of stock",
    },
];

const DesignGuide = (props: Props) => {
    return (
        <>
            <h1>Wall Street Design Guide</h1>
            <h2>Design your portfolio</h2>
            <RatioList data={testIncomeStatementData} config={tableConfig} />
            <Table data={testIncomeStatementData} config={tableConfig} />
        </>
    )
}

export default DesignGuide