import React from "react";
import IexAPI from "./IexAPI";
import UserPortfolio from "./UserPortfolio";

const Portfolio = (props) => {
  return (
    <div className="home">
      Portfolio
      <IexAPI user={props.user}/>
      <UserPortfolio user={props.user} />
    </div>
  );
};

export default Portfolio;