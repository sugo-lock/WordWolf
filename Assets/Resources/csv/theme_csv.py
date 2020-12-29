import pandas as pd


IN_FPATH  = "./ThemeList.xlsx"
OUT_FPATH = "./ThemeList.csv"


df = pd.read_excel(IN_FPATH, sheet_name="Sheet1")
df_out = []

for theme in df["theme"].unique():
    df_ = df[ df["theme"] == theme ]
    df_ = df_["content"]
    
    for i in range(len(df_.index)):
        for j in range(len(df_.index)):
            if( i != j ):
                df_out.append([ df_.iloc[i], df_.iloc[j] ])
    
df_out = pd.DataFrame( df_out )
df_out.to_csv(OUT_FPATH)

