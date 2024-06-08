declare module Example.Orari.Server {
	interface indexViewModel {
		Filter: string;
		Orari: IEnumerable<OrarioIndexViewModel>;
		Nave: NaveDetailDTO;
		Giorno: Date;
		DipendentiLiberi: DipendentePerRuoloDTO[];
	}
}