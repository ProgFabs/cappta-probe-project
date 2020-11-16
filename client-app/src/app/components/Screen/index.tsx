import React, { FormEvent, useEffect, useState } from 'react'
import Probes from '../../api/agent';
import IProbe from '../../models/Probe';
import { MainContainer, Window, Terminal, Command, Log, Input } from './screen.styles';

export const Screen = () => {
  const [highland, setHighland] = useState("");
  const [probes, setProbes] = useState<IProbe[]>([])
  const [probeAmount, setProbeAmount] = useState<number>(0);
  const [probeProps, setProbeProps] = useState("");
  const [moves, setMoves] = useState("");
  const [iteration, setIteration] = useState(0);
  const [submitting, setSubmitting] = useState(false);
  const [probeLaunching, setProbeLaunching] = useState(false);
  const [response, setResponse] = useState([]);

  const handleProbeAmountChange = (event: FormEvent<HTMLInputElement>) => {
    const { value } = event.currentTarget;
    setProbeAmount(Number(value));
  }

  useEffect(() => {
    if(iteration === probeAmount && probes.length >= 1) {
      setProbeLaunching(true);
      Probes.launch(highland, probes).then((response: any) => {
        setResponse(response);
      })
    }
  }, [probeAmount, iteration, highland, probes])

  const handleProbePropsChange = (event: FormEvent<HTMLInputElement>) => {
    const { value } = event.currentTarget;

    setProbeProps(value);
  }

  const handleProbeMovesChange = (event: FormEvent<HTMLInputElement>) => {
    const { value } = event.currentTarget;

    setMoves(value);
  }

  const handleSubmit = () => {
    setIteration(iteration + 1);
    let newProbeProps = probeProps.split(' '); 

    const probe: IProbe = {
      Position_X: Number(newProbeProps[0]),
      Position_Y: Number(newProbeProps[1]),
      FacingDirection: newProbeProps[2],
      Moves: moves,
    }
    

    setSubmitting(true);
    setProbes([...probes, probe]);
    setMoves("");
    setProbeProps("");  
    setTimeout(() => setSubmitting(false), 1000)
  }

  const renderProbeDataInput = () => {
    while(iteration !== probeAmount) {
      return (
          <Log>
            <span>
              Enter probe #{iteration + 1} properties (x, y coordinates and initial facing direction):
            </span>
            <Command>
            <Input 
            type="text"
            onChange={handleProbePropsChange}
            value={probeProps}
            />
            </Command>
            <span>
              Enter probe #{iteration + 1} movements:
            </span>
            <Command>
            <Input 
            type="text"
            onChange={handleProbeMovesChange}
            onDoubleClick={() => handleSubmit()}
            />
            </Command>
          </Log>
      )
    }
  }              

  return (
    <MainContainer>
      <Window>
        <Terminal>
          <Command>git clone https://github.com/ProgFabs/cappta-probe-project</Command>
          <Log>
            <span>
              Cloning into 'cappta-probe-project'...<br />
              remote: Reusing existing pack: 1857, done.<br />
              remote: Total 1857 (delta 0), reused 0 (delta 0)<br />
              Receiving objects: 100% (1857/1857), 374.35 KiB | 268.00 KiB/s, done.<br />
              Resolving deltas: 100% (772/772), done.<br />
              Checking connectivity... done. <br /> <br /> 
            </span>
            <span>
              yarn run v1.22.5 <br />
              Starting the development server <br />
              Compiled successfully! <br />
              Welcome to ProbeLauncher by Cappta©  <br /> <br />
              How many probes will you send to Mars? <br />
            </span>
          </Log>
          <Log>
          </Log>
          <Command>
            <Input 
            onChange={handleProbeAmountChange}
            />
          </Command>
          {probeAmount > 0 && !probeLaunching && (
          <Log>
            <span>
              Enter the highland x, y boundaries:
            </span> <br />
            <Command>
            <Input 
            type="text"
            onChange={(event: FormEvent<HTMLInputElement>) => setHighland(event.currentTarget.value)}
            />
            </Command>
          {highland && !submitting && renderProbeDataInput()}
          </Log>
          )}
          {probeLaunching && (
          <Log>
            <span>
              Probe(s) launched! Waiting for a response from the server...
            </span> <br />
            <span>
              Probes' position: <br />
              {response.map((res) => {
                return <><span>{res}</span> <br /></>
              })}
            </span>
          {highland && !submitting && renderProbeDataInput()}
          </Log>
          )}
          
        </Terminal>
      </Window>
    </MainContainer>
  )
}

export default Screen;
