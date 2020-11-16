import React from 'react';
import { MainContainer, Heading, LogoImage } from "./header.styles";

export const Header = () => {
  return (
    <MainContainer>
      <Heading>ProbeLauncher</Heading> 
      <Heading>
        <span style={{marginRight: 5}}>powered by</span>
        <a 
        target="_blank" 
        rel="noreferrer"
        href={"https://www.cappta.com.br"}>
          <LogoImage src="https://www.cappta.com.br/images/desktop/cappta_white.png" alt="logo" />
        </a>
      </Heading>
    </MainContainer>
  )
}

export default Header;
