import React from "react";
import logo from "../../assets/wallStreetLogo.jpg";
import "./Navbar.css";

interface Props {}

const Navbar = (props: Props) => {
  return (
    <nav className="relative mx-auto p-6 max-w-screen-xl">
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-20">
          <img src={logo} alt="logo" className="w-36 h-12" />
          <div className="hidden lg:flex font-bold">
            <a
              href="#"
              className="text-black hover:text-dark-blue"
            >
              Dashboard
            </a>
          </div>
        </div>

        <div className="hidden lg:flex items-center space-x-6 text-back">
          <div className="hover:text-dark-blue">Login</div>
          <a
            href="#"
            className="px-8 py-3 font-bold rounded bg-light-green text-white hover:opacity-70"
          >
            Signup
          </a>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;