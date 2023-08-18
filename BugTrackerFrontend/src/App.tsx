import React, { useEffect, useState } from 'react';
import { Routes, Route, Navigate } from "react-router-dom"
import './App.css';
import {
    Home,
    ProfileProjects,
    ProfileIssues,
    IssueDetails,
    ProjectDetails,
    CreateProject,
    CreateIssue,
    EditIssue,
    EditProject
} from './Views/exports';
import { Navbar } from "./Containers/exports"

function App() {
    const [poster, setPoster] = useState<string | undefined>(undefined)

    useEffect(() => {
        ; (async () => {
            const baseURL = process.env.REACT_APP_BASE_URL
            const url = `${baseURL ? baseURL : "https://localhost:7104/"}user`

            const options: RequestInit = {
                method: "GET",
                credentials: "include"
            }

            const response = await fetch(url, options)

            if (response.ok) {
                const json = await response.json()
                setPoster(json.Name)
            }
        })()
    }, [])

    return (
        <div className="app">
            <Navbar poster={poster} setPoster={setPoster} />
            <Routes>
                <Route path="/" element={<Home />} />
                {poster !== undefined
                    ? (
                        <>
                            <Route path="/new-project" element={<CreateProject poster={poster} />} />

                            <Route path="/project/:projId/edit" element={<EditProject />} />
                            <Route path="/project/:projId/new" element={<CreateIssue poster={poster} />} />
                            <Route path="/project/:projId/issue/:issueId/edit" element={<EditIssue poster={poster} />} />

                            <Route path="/profile/projects" element={<ProfileProjects />} />
                            <Route path="/profile/issues" element={<ProfileIssues />} />
                        </>

                    )
                    : <Route path="/new-project" element={<Navigate to="/" />} />
                }
                <Route path="/project/:projId" element={<ProjectDetails poster={poster} />} />
                <Route path="/project/:projId/issue/:issueId" element={<IssueDetails poster={poster} />} />


            </Routes>
        </div>
    );
}

export default App;
