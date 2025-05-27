import matplotlib.pyplot as plt
import numpy as np
import os
from matplotlib.ticker import AutoMinorLocator

plt.style.use('seaborn-v0_8-darkgrid')

project_root = os.path.dirname(os.path.abspath(__file__))
data_path = os.path.join(project_root, "result", "data.txt")
plot_path = os.path.join(project_root, "result", "plot.png")

radius = []
ns = []
with open(data_path, "r") as f:
    for line in f:
        parts = line.strip().split(" ")
        rad = float(parts[0].replace(',', '.'))  # Замена запятой на точку
        n = float(parts[1].replace(',', '.'))    # Замена запятой на точку
        radius.append(rad)
        ns.append(n)

fig, ax = plt.subplots(figsize=(12, 7), dpi=300)

line = ax.plot(radius, ns, 
                color='#3498db', 
                marker='o', 
                markersize=8,
                markerfacecolor='#e74c3c',
                markeredgecolor='#c0392b',
                markeredgewidth=1,
                linewidth=2.5,
                linestyle='-',
                alpha=0.8,
                label="Зависимость точности от радиуса точки")

ax.set_title("Зависимость точности от радиуса конечной точки", 
            fontsize=14, pad=20, fontweight='bold')
ax.set_xlabel("Радиус конечной точки", fontsize=12, labelpad=10)
ax.set_ylabel("Точность", fontsize=12, labelpad=10)

ax.tick_params(axis='both', which='major', labelsize=10)
ax.xaxis.set_minor_locator(AutoMinorLocator())
ax.yaxis.set_minor_locator(AutoMinorLocator())
ax.tick_params(which='both', width=1)
ax.tick_params(which='major', length=6)
ax.tick_params(which='minor', length=3)

ax.grid(True, which='major', linestyle='-', linewidth=0.7, alpha=0.7)
ax.grid(True, which='minor', linestyle=':', linewidth=0.5, alpha=0.5)

legend = ax.legend(frameon=True, fontsize=11, 
                    framealpha=1, shadow=True, 
                    borderpad=1, loc='best')
legend.get_frame().set_facecolor('white')
legend.get_frame().set_edgecolor('#bdc3c7')

plt.tight_layout()

plt.savefig(plot_path, dpi=300, bbox_inches='tight', facecolor=fig.get_facecolor())
plt.close(fig)