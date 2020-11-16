import styled from 'styled-components';

export const MainContainer = styled.div`
  margin-top: 48px;
  height: 700px;
  margin-bottom: 48px;
  display: flex;
  width: 100%;
  @keyframes write-command {
    0% {
      width: 0%;
    }
    
    
    100% {
      width: 100%;
    }
  }

  @keyframes write-log {
    0% {
      height: 0;
    }
    
    16% {
      height: 0;
    }
    
    17% {
      height: 18px;
    }
    
    33% {
      height: 18px;
    }
    
    34% {
      height: 37px;
    }
    
    51% {
      height: 37px;
    }
    
    52% {
      height: 55px;
    }
    
    69% {
      height: 55px;
    }
    
    70% {
      height: 74px;
    }
    
    87% {
      height: 74px;
    }
    
    88% {
      height: 92px;
    }
    
    88% {
      height: 92px;
    }
    
    99% {
      height: 92px;
    }
    
    100% {
      height: 100%;
    }
  }
`

export const Window = styled.div`
  border-radius: 3px;
  background: #222;
  color: #fff;
  position: relative;
  margin: 0 auto;
  width: 80%;
  overflow-y: auto;
  
  &:before {
    content: ' ';
    display: block;
    height: 48px;
    background: #C6C6C6;
  }
  
  &:after {
    content: '. . .';
    position: absolute;
    left: 12px;
    right: 0;
    top: -3px;
    font-family: "Times New Roman", Times, serif;
    font-size: 96px;
    color: #fff;
    line-height: 0;
    letter-spacing: -12px;
  }
`

export const Terminal = styled.div`
  margin: 20px;
  font-family: monospace;
  font-size: 16px;
  color: #22da26;
`

export const Command = styled.p`
  width: 0%;
  white-space: nowrap;
  overflow: hidden;
  animation: write-command 5s both;

      &:before {
      content: '$ ';
      color: #22da26;
    }
`
export const Log = styled.p`
  white-space: nowrap;
  overflow: hidden;
  animation: write-log 5s both;
`

export const Input = styled.input`
  background: #242424;
  outline: none;
  border: none;
  border-bottom: #22da26;
  color: #22da26;
`

