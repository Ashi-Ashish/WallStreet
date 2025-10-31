import { Outlet } from "react-router";
import "./App.css";
import "react-toastify/Dist/ReactToastify.css";
import Navbar from "./Components/Navbar/Navbar";
import { ToastContainer } from "react-toastify/unstyled";
import { UserProvider } from "./Context/useAuth";

function App() {
  return (
    <>
      <UserProvider>
        <Navbar />
        <Outlet />
        <ToastContainer />
      </UserProvider>
    </>
  );
}

export default App;
