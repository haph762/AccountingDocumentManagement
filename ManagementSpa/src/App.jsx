import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import DocumentForm from "./pages/DocumentForm";
import DocumentDetails from "./pages/DocumentDetails";
import "./App.css";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/add" element={<DocumentForm />} />
        <Route path="/edit/:id" element={<DocumentForm />} />
        <Route path="/details/:id" element={<DocumentDetails />} />
      </Routes>
    </Router>
  );
}

export default App;
