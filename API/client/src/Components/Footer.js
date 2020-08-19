import React from "react";
import JkLogo from "../Images/titleGraphicWithLogoOPTIMIZED.svg";

const Footer = () => {
  return (
    <footer>
      <img id="jk-logo" width="15%" src={JkLogo} alt="Jeff King" />
      <div>
        <a href="https://github.com/jazfunk">GitHub</a>
        &nbsp; &nbsp;
        <a href="https://www.linkedin.com/in/jeffking222/">Linkedin</a>
        &nbsp;&nbsp;
        <a href="https://www.jeff-king.net">Website</a>
      </div>
    </footer>
  );
}

export default Footer;
