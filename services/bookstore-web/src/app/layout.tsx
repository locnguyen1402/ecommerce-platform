import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";

import { ReactNode } from "react";

import type { Metadata } from "next";

import App from "@/shared/app/App";

export const metadata: Metadata = {
  title: "Vi Books",
  description: "Knowledge is power",
};

type Props = {
  children: ReactNode;
};

const RootLayout = (props: Props) => {
  return (
    <html
      lang="en"
      style={{
        scrollBehavior: "smooth",
      }}
      suppressHydrationWarning
    >
      <body>
        <App>{props.children}</App>
      </body>
    </html>
  );
};

export default RootLayout;
