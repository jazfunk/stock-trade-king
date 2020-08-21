import React from "react";
import IexAPI from "./IexAPI";

const Portfolio = (props) => {
  return (
    <div className="home">
      Portfolio
      <IexAPI user={props.user}/>
    </div>
  );
};

export default Portfolio;